import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenuComponent } from './NavMenuComponent';

export class LayoutComponent extends Component {
  static displayName = LayoutComponent.name;

  render() {
    return (
      <div>
        <NavMenuComponent />
        <Container tag="main">
          {this.props.children}
        </Container>
      </div>
    );
  }
}
