import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import AppRoutes from './routes/AppRoutes';
import { LayoutComponent } from './components/LayoutComponent';
import './styles/custom.css';

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <LayoutComponent>
        <Routes>
          {AppRoutes.map((route, index) => {
            const { element, ...rest } = route;
            return <Route key={index} {...rest} element={element} />;
          })}
        </Routes>
      </LayoutComponent>
    );
  }
}
