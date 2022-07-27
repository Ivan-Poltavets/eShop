import React from 'react';

const Card = (props:any) => {
    return (
        <div className={"card"}>
            <h3 className={"header"}>{props.name}</h3>
            <p className={"description"}>{props.description}</p>
            <h4 className={"price"}>{props.price}</h4>
            <button>Buy</button>
        </div>
    );
};

export default Card;