import java.util.List;

public class UserService {
    private UserDAO userDAO;

    public UserService(UserDAO userDAO) {
        this.userDAO = userDAO;
    }

    public void addUser(User user) {
        userDAO.addUser(user);
    }

    public User getUserById(int id) {
        return userDAO.getUserById(id);
    }

    public void updateUser(User updatedUser) {
        userDAO.updateUser(updatedUser);
    }

    public void deleteUser(int id) {
        userDAO.deleteUser(id);
    }

    public List<User> getAllUsers() {
        return userDAO.getAllUsers();
    }
}
