import React from 'react';
import {Link} from "react-router-dom";

const NavBar = () => {
    return (
        <div>
            <ul>
                <li>
                    <Link to={"/"}>Catalog</Link>
                </li>
                <li>
                    <Link to={"/something"}>Something</Link>
                </li>
            </ul>
        </div>
    );
};

export default NavBar;