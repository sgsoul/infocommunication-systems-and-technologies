public class MainApplication {
    public static void main(String[] args) {
        EquipmentController equipmentController = new EquipmentController(new EquipmentService(new EquipmentDAO()));
        UserController userController = new UserController(new UserService(new UserDAO()));

        EquipmentView equipmentView = new EquipmentView(equipmentController);
        UserView userView = new UserView(userController);

        equipmentView.run();
        userView.run();
    }
}
