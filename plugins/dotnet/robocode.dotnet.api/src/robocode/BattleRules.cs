#region Copyright (c) 2001-2013 Mathew A. Nelson and Robocode contributors

// Copyright (c) 2001-2013 Mathew A. Nelson and Robocode contributors
// All rights reserved. This program and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://robocode.sourceforge.net/license/epl-v10.html

#endregion

using System;
using net.sf.robocode.security;

namespace Robocode
{
    ///<summary>
    ///  Contains the battle rules returned by <see cref="Robocode.Control.Events.BattleStartedEvent.BattleRules">BattleStartedEvent.BattleRules</see>
    ///  when a battle is started and <see cref="Robocode.Control.Events.BattleCompletedEvent.BattleRules">BattleCompletedEvent.getBattleRules</see>
    ///  when a battle is completed.
    ///  <seealso cref="Robocode.Control.Events.BattleStartedEvent"/>BattleStartedEvent</seealso>
    ///  <seealso cref="Robocode.Control.Events.BattleCompletedEvent"/>BattleCompletedEvent</seealso>
    ///</summary>
    [Serializable]
    public sealed class BattleRules
    {
        private readonly int battlefieldWidth;
        private readonly int battlefieldHeight;
        private readonly int numRounds;
        private readonly double gunCoolingRate;
        private readonly long inactivityTime;
        private readonly bool hideEnemyNames;
        private readonly int sentryRobotAttackRange;

        ///<summary>
        ///  Returns the battlefield width.
        ///</summary>
        public int BattlefieldWidth
        {
            get { return battlefieldWidth; }
        }

        ///<summary>
        ///  Returns the battlefield height.
        ///</summary>
        public int BattlefieldHeight
        {
            get { return battlefieldHeight; }
        }

        ///<summary>
        ///  Returns the number of rounds.
        ///</summary>
        public int NumRounds
        {
            get { return numRounds; }
        }

        ///<summary>
        ///  Returns the rate at which the gun will cool down, i.e. the amount of heat the gun heat will drop per turn.
        ///  <p />
        ///  The gun cooling rate is default 0.1 per turn, but can be changed by the battle setup.
        ///  So don't count on the cooling rate being 0.1!
        ///  <seealso cref="Robot.GunHeat"/>
        ///  <seealso cref="Robot.Fire(double)"/>
        ///  <seealso cref="Robot.FireBullet(double)"/>
        ///</summary>
        public double GunCoolingRate
        {
            get { return gunCoolingRate; }
        }

        ///<summary>
        ///  Returns the allowed inactivity time, where the robot is not taking any action, before will begin to be zapped.
        ///  The inactivity time is measured in turns, and is the allowed time that a robot is allowed to omit taking
        ///  action before being punished by the game by zapping.
        ///  <p />
        ///  When a robot is zapped by the game, it will loose 0.1 energy points per turn. Eventually the robot will be
        ///  killed by zapping until the robot takes action. When the robot takes action, the inactivity time counter is
        ///  reset.
        ///  <p />
        ///  The allowed inactivity time is per default 450 turns, but can be changed by the battle setup.
        ///  So don't count on the inactivity time being 450 turns!
        ///  <seealso cref="Robot.DoNothing()"/>
        ///  <seealso cref="AdvancedRobot.Execute()"/>
        ///</summary>
        public long InactivityTime
        {
            get { return inactivityTime; }
        }

        ///<summary>
        ///  Returns true if the enemy names are hidden, i.e. anonymous; false otherwise.
        ///</summary>
        public bool HideEnemyNames
        {
            get { return hideEnemyNames; }
        }

        ///<summary>
        ///  Returns the attack range for a <see cref="Robocode.SentryRobot">SentryRobot</see>.
        ///</summary>
        public int SentryRobotAttackRange
        {
            get { return sentryRobotAttackRange; }
        }

        private BattleRules(int battlefieldWidth, int battlefieldHeight, int numRounds, double gunCoolingRate, long inactivityTime,
            bool hideEnemyNames, int sentryRobotAttackRange)
        {
            this.battlefieldWidth = battlefieldWidth;
            this.battlefieldHeight = battlefieldHeight;
            this.numRounds = numRounds;
            this.gunCoolingRate = gunCoolingRate;
            this.inactivityTime = inactivityTime;
            this.hideEnemyNames = hideEnemyNames;
            this.sentryRobotAttackRange = sentryRobotAttackRange;
        }

        private static IHiddenRulesHelper createHiddenHelper()
        {
            return new HiddenHelper();
        }

        private class HiddenHelper : IHiddenRulesHelper
        {
            public BattleRules createRules(int battlefieldWidth, int battlefieldHeight, int numRounds, double gunCoolingRate, long inactivityTime,
                bool hideEnemyNames, int sentryRobotAttackRange)
            {
                return new BattleRules(battlefieldWidth, battlefieldHeight, numRounds, gunCoolingRate, inactivityTime, hideEnemyNames, sentryRobotAttackRange);
            }
        }
    }
}

//doc