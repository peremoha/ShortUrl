import React, { Component, useEffect, useState } from 'react';
import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import { useAuth } from '../../context/AuthContext';
import { useLocalStorage } from '../../hooks/useLocalStorage';
import './NavMenu.css';
import logo from '../../static/images/logo.png';

const NavMenu = () => {
  const { setUser, isLoggedIn, setIsLoggedIn } = useAuth();
  const { removeItem } = useLocalStorage();

  const handleLogout = () => {
    setIsLoggedIn(false);
    setUser(null);
    removeItem('user');
  }

  return (
    <header>
      <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" container light>
        <NavbarBrand tag={Link} to="/">
          <div className='logoImage'>
            <img src={logo} alt='LOGO' />
          </div>
          Inforce</NavbarBrand>
        <ul className="navbar-nav flex-grow">
          <NavItem>
            <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
          </NavItem>
          {isLoggedIn ?
            <NavItem>
              <NavLink tag={Link} className="text-dark" onClick={handleLogout} to="/">Exit</NavLink>
            </NavItem>
            :
            <>
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/register">Register</NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/login">Login</NavLink>
              </NavItem>
            </>
          }
        </ul>
      </Navbar>
    </header>
  );
}

export default NavMenu;