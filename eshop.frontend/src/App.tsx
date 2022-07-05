import React from 'react';
import AppRouter from "./AppRouter";
import NavBar from "./components/NavBar/NavBar";


function App() {
  return (
    <div className="App">
        <NavBar/>
        <AppRouter/>
    </div>
  );
}

export default App;
