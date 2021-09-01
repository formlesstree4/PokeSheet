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
      <AppBar position="sticky">
        <Toolbar>
          <Typography variant="h4">
            PtaSheet
          </Typography>
          <Button edge="end" component={Link} to="/" label="signal" value="signal" color="inherit">
            Home
          </Button>
          <Button edge="end" component={Link} to="/sheet" label="signal" value="signal" color="inherit">
            Pokemon Sheet
          </Button>
          <Button edge="end" component={Link} to="/ability" label="signal" value="signal" color="inherit">
            Abilities
          </Button>
          <Button edge="end" component={Link} to="/moves" label="signal" value="signal" color="inherit">
            Moves
          </Button>
          <Button edge="end" component={Link} to="/natures" label="signal" value="signal" color="inherit">
            Nature Chart
          </Button>
          <Button edge="end" component={Link} to="/pokedex" label="signal" value="signal" color="inherit">
            Pokedex
          </Button>
          <Button edge="end" component={Link} to="/types" label="signal" value="signal" color="inherit">
            Type Chart
          </Button>
        </Toolbar>
      </AppBar>
    );
  }
}
