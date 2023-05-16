import java.util.ArrayList;
import java.util.List;

public class EquipmentDAO {
    private List<Equipment> equipmentList;

    public EquipmentDAO() {
        equipmentList = new ArrayList<>();
    }

    public void addEquipment(Equipment equipment) {
        equipmentList.add(equipment);
    }

    public Equipment getEquipmentById(int id) {
        for (Equipment equipment : equipmentList) {
            if (equipment.getId() == id) {
                return equipment;
            }
        }
        return null;
    }

    public void updateEquipment(Equipment updatedEquipment) {
        for (Equipment equipment : equipmentList) {
            if (equipment.getId() == updatedEquipment.getId()) {
                equipment.setName(updatedEquipment.getName());
                equipment.setType(updatedEquipment.getType());
                equipment.setStatus(updatedEquipment.getStatus());
                break;
            }
        }
    }

    public void deleteEquipment(int id) {
        Equipment equipmentToRemove = null;
        for (Equipment equipment : equipmentList) {
            if (equipment.getId() == id) {
                equipmentToRemove = equipment;
                break;
            }
        }
        if (equipmentToRemove != null) {
            equipmentList.remove(equipmentToRemove);
        }
    }

    public List<Equipment> getAllEquipment() {
        return equipmentList;
    }
}
