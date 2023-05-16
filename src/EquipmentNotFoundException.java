public class EquipmentNotFoundException extends Exception {
    private int equipmentId;

    public EquipmentNotFoundException(int equipmentId) {
        super("Equipment not found with ID: " + equipmentId);
        this.equipmentId = equipmentId;
    }

    public int getEquipmentId() {
        return equipmentId;
    }
}
