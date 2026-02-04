"use client";

import styles from "./page.module.css";
import { LoginForm } from "@/components/Login/LoginForm";
import { User } from "@/types";
import { useRouter } from "next/navigation";

export default function Home() {
  const router = useRouter();

  // some temporary users
  const users = [
    { name: "Han Solo", subName: "(honest)", id: "10017dc4-df8f-4a01-ad4d-5a0b62e7ff48" },
    { name: "Arnold Rimmer", subName: "Flying Ace", id: "97b81a67-1775-4253-be07-c73605334517" },
  ] as User[];

  const onSelectUser = (user: User) => {
    router.push(`/tasks/${user.id}`);
  };

  return (
    <div className={styles.page}>
      <div className={styles.center}>
        <main className={styles.main}>
          <div className={styles.intro}>
            <LoginForm users={users} onSelectUser={onSelectUser} />
          </div>
        </main>
      </div>
    </div>
  );
}
