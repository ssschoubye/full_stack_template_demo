import React from 'react';
import { Link } from 'react-router-dom';
import Logo from '../../../Images/logo.png';


const Header = () => {
    return (
      <header className="header">
        <h1>
          <img 
            src={Logo} 
            alt="Medical Planners Logo"
            className="header-logo"
          />
        </h1>
        <nav>
        <ul className="left-nav">
          <li><Link to="/">Home</Link></li>
          <li><Link to="/doctor-types">Vores Lægetyper</Link></li>
        </ul>
       </nav>
      </header>
    );
  };

  export default Header;