import React, {useEffect, useState} from 'react';
import {CatalogDto, Client} from "../../api/Api";
import Card from "../Card/Card";

const apiClient = new Client('https://localhost:7214');

const CardList = () => {
    const [items,setItems] = useState<CatalogDto[] | undefined>(undefined);

    async function getItems(){
        const itemsDto = await apiClient.getCatalog(10,0,"1.0");
        setItems(itemsDto);
    }

    useEffect(() =>{
        getItems();
    },[])

    return (
        <div>
            {items?.map((item) => (
                <Card name={`${item.brandName} ${item.itemName}`} description={item.description} price={item.price}/>
            ))}
        </div>
    );
};

export default CardList;