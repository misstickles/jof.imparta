"use client";

import { useEffect, useState } from "react";
import styles from "../../page.module.css";
import { TaskList } from "@/components/Task";
import { Header } from "@/components/Header";
import { useFetchTasks } from "@/hooks/useFetchTasks";
import { useFetchProfile } from "@/hooks/useFetchProfile";
import { TaskStatus } from "@/types";
import { NewTask } from "@/components/Modify";

const Page = ({ params }: { params: Promise<{ userId: string }> }) => {
  const [userId, setUserId] = useState<string>("");

  useEffect(() => {
    const getUserId = async () => {
      const { userId } = await params;
      setUserId(userId);
    };

    getUserId();
  }, [userId, params]);

  const {
    taskList,
    error: taskError,
    loading: taskLoading,
    handleCreateTask,
    handleDeleteTask,
    handleUpdateStatus,
    handleUpdateTask,
  } = useFetchTasks(userId);

  const { profile, error: profileError, loading: profileLoading, handleUploadAvatar } = useFetchProfile(userId);

  const onAvatarClick = () => {
    console.log("avatar click");
  };

  const onClickNewTask = (title: string, description: string) => {
    handleCreateTask(title, description);
  };

  const onStatusChange = (taskId: string, status: TaskStatus) => {
    handleUpdateStatus(taskId, status);
  };

  const onDeleteTask = (taskId: string) => {
    handleDeleteTask(taskId);
  };

  const onUpdateTask = (taskId: string, title: string, description: string) => {
    handleUpdateTask(taskId, title, description);
  };

  return (
    <div className={styles.page}>
      <main className={`${styles.main} ${styles.center}`}>
        <Header
          tasks={taskList}
          profile={profile}
          loading={profileLoading}
          error={profileError}
          onAvatarClick={onAvatarClick}
        />
        <NewTask onClickNewTask={onClickNewTask} />
        <TaskList
          tasks={taskList}
          loading={taskLoading}
          error={taskError}
          onStatusChange={onStatusChange}
          onUpdateTask={onUpdateTask}
          onDeleteTask={onDeleteTask}
        />
      </main>
    </div>
  );
};

export default Page;
