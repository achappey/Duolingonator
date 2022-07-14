import React, { Component } from 'react';
import { Route, Routes } from 'react-router';
import { Home } from './components/Home';

import { Stack, StackItem } from '@fluentui/react';
import { Header } from './components/Header';
import { SideNavigation } from './components/SideNavigation';
import { initializeIcons } from '@fluentui/font-icons-mdl2';
import { Access } from './components/Access';
import { ThemeProvider, PartialTheme } from '@fluentui/react';

initializeIcons();

const appTheme: PartialTheme = {
  palette: {
    themePrimary: '#78C800'
  }
};

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (<>
      <ThemeProvider theme={appTheme}>
        <Stack>
          <StackItem style={{ width: "100%" }}>
            <Header />
          </StackItem>
        </Stack>
        <Stack horizontal={true}>
          <StackItem>
            <SideNavigation />
          </StackItem>
          <StackItem style={{ paddingLeft: 20 }}>
            <Routes>
              <Route path='/' element={<Home />} />
              <Route path='/access' element={<Access />} />
            </Routes>
          </StackItem>
        </Stack>
      </ThemeProvider>
    </>
    );
  }
}
