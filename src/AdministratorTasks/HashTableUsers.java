import Actors.User;

public class HashTableUsers {

    private int size;
    private String[] keys;
    private String[] values;

    public HashTableUsers(int size) {
        this.size = size;
        keys = new String[size];
        values = new String[size];
    }
    
    private int hashFunction(String key){
        int hashCode = key.hashCode();
        return Math.abs(hashCode % size);
    }
    
    public void add(String key, String value){
        int index = hashFunction(key);
        
        while(keys[index] != null && !keys[index].equals(key)){
            index = (index + 1) % size;
        }
        
        keys[index] = key;
        values[index] = value;
    }
    
    public User search(String key){
        int index = hashFunction(key);
        
        while(keys[index] != null){
            if(keys[index].equals(key)){
                System.out.println("Usuario encontrado: " + keys[index] + values[index]);
            }
            index = (index + 1) % size;
        }
        System.out.println("No encontrado");
        return null;
    }
    
    public void delete(String key){
        int index = hashFunction(key);
        
        while(keys[index] != null){
            if(keys[index].equals(key)){
                keys[index] = null;
                values[index] = null;
                System.out.println("Usuario eliminado: " + key + " del indice" + index);
                return;
            }
            index = (index + 1) % size;
        }
        System.out.println("Usuario no encontrado");
    }
    
}
