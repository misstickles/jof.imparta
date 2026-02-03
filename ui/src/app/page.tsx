import Image from "next/image";
import styles from "./page.module.css";
import { LoginForm } from "@/components/Login/LoginForm";

export default function Home() {
  return (
    <div className={styles.page}>
      <div className={styles.center}>
        <main className={styles.main}>
          <div className={styles.intro}>
            <LoginForm />
          </div>
        </main>
      </div>
    </div>
  );
}
