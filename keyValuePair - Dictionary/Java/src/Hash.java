import java.nio.charset.StandardCharsets;

public class Hash {
    public void Hash32(String str){
        final long OFFSET_BASIS = 2166136261L;
        final long FNV_PRIME = 16777619L;
        byte[] data = str.getBytes(StandardCharsets.US_ASCII);
        long hash = OFFSET_BASIS;
        for (byte b : data) {
            hash ^= b;
            hash *= FNV_PRIME;
            hash &= 0xFFFFFFFFL;
        }
        System.out.println("The Original Text : " + str + ", Hash Code : " + Long.toHexString(hash) );
    }
}
