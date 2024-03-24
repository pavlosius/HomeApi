namespace HomeApi.Contracts.Models.Rooms
{
    /// <summary>
    /// Запрос для обновления свойств подключенного устройства
    /// </summary>
    public class EditRoomRequest
    {
        public string NewName { get; set; }
        public string NewArea { get; set; }
        public string NewGasConnected { get; set; }
        public string NewVoltage { get; set; }
    }
}