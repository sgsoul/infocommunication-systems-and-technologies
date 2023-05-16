import java.util.List;

public class EquipmentService {
    private EquipmentDAO equipmentDAO;

    public EquipmentService(EquipmentDAO equipmentDAO) {
        this.equipmentDAO = equipmentDAO;
    }

    public void addEquipment(Equipment equipment) {
        equipmentDAO.addEquipment(equipment);
    }

    public Equipment getEquipmentById(int id) {
        return equipmentDAO.getEquipmentById(id);
    }

    public void updateEquipment(Equipment updatedEquipment) {
        equipmentDAO.updateEquipment(updatedEquipment);
    }

    public void deleteEquipment(int id) {
        equipmentDAO.deleteEquipment(id);
    }

    public List<Equipment> getAllEquipment() {
        return equipmentDAO.getAllEquipment();
    }
}
