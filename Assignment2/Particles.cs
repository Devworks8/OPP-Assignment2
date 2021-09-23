namespace Assignment2.Particles
{
#if DEBUG
public	class ParticleMovement
#else
	class ParticleMovement
#endif

	{
		public const int BASE_MOVEMENT = 3;
		public const int GRAVITY_MOVEMENT = 2;

		public enum MagField
        {
			ON = 1,
			OFF = 0
        }

		public enum Gravity
        {
			ON = GRAVITY_MOVEMENT,
			OFF = 0
        }

		private int _movementRange;
		private int _gravitationalField = 0;
		private decimal _magneticField = 1M;

		public int DistanceMoved;

		/// <summary>
		/// Set and Get the Patical Movement Range
		/// </summary>
		/// <param name="movementRange"></param>
		public ParticleMovement(int movementRange = BASE_MOVEMENT)
        {
			MovementRange = movementRange;
        }

		/// <summary>
		/// Set and Get the Movement Range
		/// </summary>
		public int MovementRange 
		{ 
			get => _movementRange; 
			set 
			{
				_movementRange = value;
				CalculateDistance();
			} 
		}


		/// <summary>
		/// Set and Get the Graviational Field
		/// </summary>
		public int GravitationalField
        {
			get => _gravitationalField;
            set
            {
				_gravitationalField = value;
				CalculateDistance();
            }
        }

		/// <summary>
		/// Set and Get the Magnetic Field: a value of 0 = 1M all else = 1.75M
		/// </summary>
		public decimal MagneticField
        {
			get => _magneticField;
            set
            {
				switch (value)
				{
					case (int)MagField.OFF:
						_magneticField = 1M;
						break;

					case (int)MagField.ON:
						_magneticField = 1.75M;
						break;
				}

				CalculateDistance();
            }
        }

		public int Distance { get; private set; }

		private void CalculateDistance()

		{
			DistanceMoved = (int)(MovementRange * MagneticField) + BASE_MOVEMENT + GravitationalField;
		}
	}
}
