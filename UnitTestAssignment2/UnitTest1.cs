using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestAssignment2
{
    using Assignment2.Particles;

    [TestClass]
    public class ParticleMovementTester
    {
        [TestMethod]
        public void TestConstructor()
        {
            ParticleMovement pm1 = new ParticleMovement();
            ParticleMovement pm2 = new ParticleMovement(10);

            Assert.AreEqual(ParticleMovement.BASE_MOVEMENT, pm1.MovementRange);
            Assert.AreEqual(10, pm2.MovementRange);
        }

        [TestMethod]
        public void PropertyTests()
        {
            ParticleMovement pm = new ParticleMovement();

            // Test MagneticField Property
            Assert.AreEqual(1M, pm.MagneticField);

            pm.MagneticField = (int)ParticleMovement.MagField.ON;
            Assert.AreEqual(1.75M, pm.MagneticField);

            pm.MagneticField = (int)ParticleMovement.MagField.OFF;
            Assert.AreEqual(1M, pm.MagneticField);

            //Test GravityField Property
            Assert.AreEqual(0, pm.GravitationalField);

            pm.GravitationalField = (int)ParticleMovement.Gravity.ON;
            Assert.AreEqual(ParticleMovement.GRAVITY_MOVEMENT, pm.GravitationalField);

            pm.GravitationalField = (int)ParticleMovement.Gravity.OFF;
            Assert.AreEqual(0, pm.GravitationalField);
        }

        [TestMethod]
        public void CalculateDistanceTest()
        {
            /*Default variables used for testing
             * BASE_MOVEMENT = 3
             * GRAVITY_MOVEMENT = 2
             * MagFieldON = 1.75M
             * MagFieldOFF = 1M
             * CustomMovementRange = 6
             * 
             * Calculation used:
             * (int)(MovementRange * MagneticField) + BASE_MOVEMENT + GravitationalField
             */

            ParticleMovement pm = new ParticleMovement();

            //Base movement only
            pm.MovementRange = ParticleMovement.BASE_MOVEMENT;
            pm.MagneticField = (int)ParticleMovement.MagField.OFF;
            pm.GravitationalField = (int)ParticleMovement.Gravity.OFF;

            //(3 * 1) + 3 + 0 = 6
            Assert.AreEqual(6, pm.DistanceMoved);

            //Magnetic field present only
            pm.GravitationalField = (int)ParticleMovement.Gravity.OFF;
            pm.MagneticField = (int)ParticleMovement.MagField.ON;

            //(3 * 1.75) + 3 + 0 = 8
            Assert.AreEqual(8, pm.DistanceMoved);

            //Gravitational field present only
            pm.MagneticField = (int)ParticleMovement.MagField.OFF;
            pm.GravitationalField = (int)ParticleMovement.Gravity.ON;

            //(3 * 1) + 3 + 2 = 6
            Assert.AreEqual(8, pm.DistanceMoved);

            //Both fields present
            pm.MagneticField = (int)ParticleMovement.MagField.ON;
            pm.GravitationalField = (int)ParticleMovement.Gravity.ON;

            //(3 * 1.75) + 3 + 2 = 10
            Assert.AreEqual(10, pm.DistanceMoved);

            //Custom movement range with both fields present
            pm.MovementRange = 6;
            pm.MagneticField = (int)ParticleMovement.MagField.ON;
            pm.GravitationalField = (int)ParticleMovement.Gravity.ON;

            //(6 * 1.75) + 3 + 2 = 15
            Assert.AreEqual(15, pm.DistanceMoved);
        }
    }
}