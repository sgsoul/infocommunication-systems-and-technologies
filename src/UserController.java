import java.util.List;

public class UserController {
    private UserService userService;

    public UserController(UserService userService) {
        this.userService = userService;
    }

    public void addUser(User user) {
        userService.addUser(user);
        System.out.println("User added successfully.");
    }

    public User getUserById(int id) {
        return userService.getUserById(id);
    }

    public void updateUser(User updatedUser) {
        userService.updateUser(updatedUser);
        System.out.println("User updated successfully.");
    }

    public void deleteUser(int id) {
        userService.deleteUser(id);
        System.out.println("User deleted successfully.");
    }

    public List<User> getAllUsers() {
        return userService.getAllUsers();
    }
}