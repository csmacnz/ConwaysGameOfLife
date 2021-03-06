﻿using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.Core.Tests
{
    [TestClass]
    public class GameStateTests
    {
        [TestMethod]
        public void CanConstruct()
        {
            var gameState = new GameState(new Dictionary<Cell, State>());

            Assert.IsNotNull(gameState);
        }

        [TestMethod]
        public void GivenAGameStateFromADictionary_WhenIModifyTheDictionary_ThenTheGameStateDoesNotChange()
        {
            var dictionary = new Dictionary<Cell, State>();
            dictionary[new Cell()] = State.Dead;
            dictionary[new Cell()] = State.Dead;
            var gameState = new GameState(dictionary);
            var cell = new Cell();
            dictionary[cell] = State.Alive;
            var unknownCellState = gameState.GetState(cell);
            Assert.AreEqual(unknownCellState, State.Dead);
        }

        [TestMethod]
        public void GivenAGameState_WhenIRequestAStateForAnUnknownCell_ThenIExpectAStateOfDead()
        {
            var gameState = new GameState(new Dictionary<Cell, State> { { new Cell(), State.Alive }, { new Cell(), State.Alive } });

            var unknownCellState = gameState.GetState(new Cell());
            Assert.AreEqual(unknownCellState, State.Dead);
        }

        [TestMethod]
        public void GivenAStateWith2Cells_WhenAskedForTheLiveCellsState_ThenReturnsAliveState()
        {
            var liveCell = new Cell();
            var deadCell = new Cell();
            var gameState = new GameState(new Dictionary<Cell, State> {{liveCell, State.Alive}, {deadCell, State.Dead}});

            State actualLiveCellState = gameState.GetState(liveCell);

            Assert.AreEqual(State.Alive, actualLiveCellState);
        }

        [TestMethod]
        public void GivenAStateWith2Cells_WhenAskedForTheDeadCellsState_ThenReturnsDeadState()
        {
            var liveCell = new Cell();
            var deadCell = new Cell();
            var gameState = new GameState(new Dictionary<Cell, State> { { liveCell, State.Alive }, { deadCell, State.Dead } });

            State actualDeadCellState = gameState.GetState(deadCell);

            Assert.AreEqual(State.Dead, actualDeadCellState);
        }
    }
}
