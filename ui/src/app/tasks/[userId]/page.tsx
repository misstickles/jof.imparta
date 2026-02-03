"use client";

import { useEffect, useState } from "react";
import styles from "../../page.module.css";
import { TaskList } from "@/components/Task";
import { Header } from "@/components/Header";
import { useFetchTasks } from "@/hooks/useFetchTasks";

const Page = ({ params }: { params: Promise<{ userId: string }> }) => {
  const [userId, setUserId] = useState<string>("");

  const { taskList } = useFetchTasks(userId);

  useEffect(() => {
    const getUserId = async () => {
      const { userId } = await params;
      setUserId(userId);
    };

    getUserId();
  }, [userId, params]);

  return (
    <div className={styles.page}>
      <main className={`${styles.main} ${styles.center}`}>
        <Header userId={userId} tasks={taskList} />
        <TaskList userId={userId} />
      </main>
    </div>
  );
};

export default Page;
