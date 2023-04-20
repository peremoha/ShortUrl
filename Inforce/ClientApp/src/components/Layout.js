import React, { Component } from 'react';
import { Container } from 'reactstrap';
import NavMenu from './NavMenu/NavMenu';

const Layout = (props) => {
  return (
    <div>
      <NavMenu />
      <Container tag="main">
        {props.children}
      </Container>
    </div>
  );
}

export default Layout

