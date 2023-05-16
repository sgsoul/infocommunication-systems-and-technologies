import java.util.List;

public class EquipmentController {
    private EquipmentService equipmentService;

    public EquipmentController(EquipmentService equipmentService) {
        this.equipmentService = equipmentService;
    }

    public void addEquipment(Equipment equipment) {
        equipmentService.addEquipment(equipment);
        System.out.println("Equipment added successfully.");
    }

    public Equipment getEquipmentById(int id) {
        return equipmentService.getEquipmentById(id);
    }

    public void updateEquipment(Equipment updatedEquipment) {
        equipmentService.updateEquipment(updatedEquipment);
        System.out.println("Equipment updated successfully.");
    }

    public void deleteEquipment(int id) {
        equipmentService.deleteEquipment(id);
        System.out.println("Equipment deleted successfully.");
    }

    public List<Equipment> getAllEquipment() {
        return equipmentService.getAllEquipment();
    }
}
