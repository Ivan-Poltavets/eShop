import React from 'react';
import {Routes, Route} from "react-router-dom";
import MainPage from "./pages/MainPage";

const AppRouter = () => {
    return (
        <Routes>
            <Route path={"/"} element={<MainPage/>}></Route>
        </Routes>
    );
};

export default AppRouter;