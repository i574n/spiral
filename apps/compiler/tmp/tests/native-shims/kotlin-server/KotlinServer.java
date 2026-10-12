import java.io.BufferedReader;
import java.io.ByteArrayOutputStream;
import java.io.InputStreamReader;
import java.io.PrintStream;
import java.nio.charset.StandardCharsets;
import org.jetbrains.kotlin.cli.jvm.K2JVMCompiler;

public class KotlinServer {
    public static void main(String[] arguments) throws Exception {
        String stdlib = arguments[0];
        BufferedReader jobs = new BufferedReader(new InputStreamReader(System.in, StandardCharsets.UTF_8));
        String job;
        while ((job = jobs.readLine()) != null) {
            if (job.isBlank()) continue;
            String[] fields = job.split("\t");
            ByteArrayOutputStream messages = new ByteArrayOutputStream();
            PrintStream sink = new PrintStream(messages, true, StandardCharsets.UTF_8);
            long started = System.nanoTime();
            String exit;
            try {
                exit = new K2JVMCompiler().exec(sink, fields[0], "-d", fields[1], "-no-stdlib", "-no-reflect", "-classpath", stdlib).toString();
            } catch (Throwable failure) {
                exit = "CRASH";
                failure.printStackTrace(sink);
            }
            long elapsed = (System.nanoTime() - started) / 1_000_000;
            String text = messages.toString(StandardCharsets.UTF_8).replace("\r", "").replace("\n", " / ").replace("\t", " ");
            System.out.println("DONE\t" + fields[0] + "\t" + exit + "\t" + elapsed + "\t" + text);
            System.out.flush();
        }
    }
}
