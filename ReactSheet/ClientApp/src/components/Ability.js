import React, { Component } from 'react';
import * as abilities from './data/abilities.json'
import { makeStyles } from '@material-ui/core/styles';
import InputLabel from '@material-ui/core/InputLabel';
import MenuItem from '@material-ui/core/MenuItem';
import FormControl from '@material-ui/core/FormControl';
import Select from '@material-ui/core/Select';
import Paper from '@material-ui/core/Paper';
import Grid from '@material-ui/core/Grid';
import { Container } from '@material-ui/core';


export class Ability extends Component {

  constructor(props) {
    super(props);
    this.state = {
      pokemonAbilities: abilities.Abilities, currentAbility: abilities.Abilities[0], style: makeStyles((theme) => ({
        root: {
          flexGrow: 1,
        },
        smallPaper: {
          padding: theme.spacing(2),
          textAlign: 'right',
          color: theme.palette.text.secondary
        },
        bigPaper: {
          padding: theme.spacing(2),
          textAlign: 'left',
          color: theme.palette.text.secondary,
        },
        formControl: {
          margin: theme.spacing(1),
          minWidth: 120,
        }
      }))
    };
    this.handleChange = this.handleChange.bind(this);
  }

  handleChange(event) {
    this.setState({
      currentAbility: this.state.pokemonAbilities.find(a => a.Name.toLocaleLowerCase() === event.target.value.toLocaleLowerCase())
    });
  }

  render() {
    return (
      <div>
        <FormControl className={this.state.style.formControl}>
          <InputLabel id="ability-select-label">Ability</InputLabel>
          <Select
            labelId="ability-select-label"
            id="ability-select"
            value={this.state.currentAbility.Name}
            onChange={this.handleChange}>
            {
              this.state.pokemonAbilities &&
              this.state.pokemonAbilities.map((h, i) =>
                (<MenuItem key={i} value={h.Name}>{h.Name}</MenuItem>))
            }
          </Select>
        </FormControl>
        <br />
        <Container>
          <Grid container spacing={3}>
            <Grid item xs={6} sm={3}>
              <Paper className={this.state.style.smallPaper}>Name:</Paper>
            </Grid>
            <Grid item xs={12} sm={9}>
              <Paper className={this.state.style.bigPaper}>{this.state.currentAbility.Name}</Paper>
            </Grid>
            <Grid item xs={6} sm={3}>
              <Paper className={this.state.style.smallPaper}>Activation:</Paper>
            </Grid>
            <Grid item xs={12} sm={9}>
              <Paper className={this.state.style.bigPaper}>{this.state.currentAbility.Activation}</Paper>
            </Grid>
            <Grid item xs={6} sm={3}>
              <Paper className={this.state.style.smallPaper}>Limit:</Paper>
            </Grid>
            <Grid item xs={12} sm={9}>
              <Paper className={this.state.style.bigPaper}>{this.state.currentAbility.Limit}</Paper>
            </Grid>
            <Grid item xs={6} sm={3}>
              <Paper className={this.state.style.smallPaper}>Keyword:</Paper>
            </Grid>
            <Grid item xs={12} sm={9}>
              <Paper className={this.state.style.bigPaper}>{this.state.currentAbility.Keyword}</Paper>
            </Grid>
            <Grid item xs={6} sm={3}>
              <Paper className={this.state.style.smallPaper}>Effect:</Paper>
            </Grid>
            <Grid item xs={12} sm={9}>
              <Paper className={this.state.style.bigPaper}>{this.state.currentAbility.Effect}</Paper>
            </Grid>
          </Grid>
        </Container>

      </div>

    );
  }
}
