namespace HomeApi.Data.Queries
{
    /// <summary>
    /// Класс для передачи дополнительных параметров при обновленнии данных о комнате
    /// </summary>
    public class UpdateRoomQuery
    {
        public string NewName { get; }
        public string NewArea { get; }
        public string NewGasConnected { get; }
        public string NewVoltage { get; }

        public UpdateRoomQuery(
            string newName = null,
            string newArea = null,
            string newGasConnected = null,
            string newVoltage = null
        )
        {
            NewName = newName;
            NewArea = newArea;
            NewGasConnected = newGasConnected;
            NewVoltage = newVoltage;
        }
    }
}