import React from 'react';
import Card from "../components/Card/Card";


const MainPage = () => {
    return (
        <div>
            <p>Main page</p>
            <Card name={"Name"} description={"Description"} price={"price"}></Card>
        </div>
    );
};

export default MainPage;