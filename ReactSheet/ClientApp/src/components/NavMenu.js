import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import './NavMenu.css';


export class NavMenu extends Component {
  render() {
    return (
      <AppBar position="fixed">
        <Toolbar>
          <Typography variant="h4">
            PtaSheet
          </Typography>
          <Button
            edge="end"
            component={Link}
            to="/"
            label="signal"
            value="signal"
            color="inherit">
            Home
          </Button>
          <Button
            edge="end"
            component={Link}
            to="/ability"
            label="signal"
            value="signal"
            color="inherit">
            Abilities
          </Button>
        </Toolbar>
      </AppBar>
    );
  }
}
