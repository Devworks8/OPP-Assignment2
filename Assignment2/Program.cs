using System;
using Assignment2.CardPicker;
using Assignment2.Particles;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
			ParticleMovement particleMover = new ParticleMovement();

			while (true)
			{
				Console.Write("0 for base movement only\n1 if a magnetic field is present\n" +
							  "2 if a gravitational field is present\n3 for both fields\n");
				
				char key = Console.ReadKey().KeyChar;
				
				if (key != '0' && key != '1' && key != '2' && key != '3') break;
				
				particleMover.MovementRange = GetMovementRange();
				
				switch (key)
                {
					case '0':
						particleMover.MovementRange = ParticleMovement.BASE_MOVEMENT;
						particleMover.MagneticField = (int)ParticleMovement.MagField.OFF;
						particleMover.GravitationalField = (int)ParticleMovement.Gravity.OFF;
						break;

					case '1':
						particleMover.GravitationalField = (int)ParticleMovement.Gravity.OFF;
						particleMover.MagneticField = (int)ParticleMovement.MagField.ON;
						break;

					case '2':
						particleMover.MagneticField = (int)ParticleMovement.MagField.OFF;
						particleMover.GravitationalField = (int)ParticleMovement.Gravity.ON;
						break;

					case '3':
						particleMover.MagneticField = (int)ParticleMovement.MagField.ON;
						particleMover.GravitationalField = (int)ParticleMovement.Gravity.ON;
						break;
                }

				Console.WriteLine($"\nParticle with a movement range of {particleMover.MovementRange} units" +
								  $" moved a total distance of {particleMover.DistanceMoved} units.\n");
			}

            foreach (string card in Card.PickSomeCards(10))
            {
                Console.WriteLine(card);
            }
        }

		private static int GetMovementRange()
		{
			Random random = new Random(1);

			return random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
		}
	}
}
