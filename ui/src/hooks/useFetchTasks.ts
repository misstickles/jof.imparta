/* eslint-disable @typescript-eslint/no-explicit-any */
import { taskApi } from "@/api/taskApi";
import { mapToTaskItems } from "@/mapping";
import { Task, TaskStatus } from "@/types";
import { useEffect, useState } from "react";

export function useFetchTasks(userId: string) {
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  const [taskList, setTaskList] = useState<Task[]>([] as Task[]);
  const [deleteResult, setDeleteResult] = useState(false);

  useEffect(() => {
    fetchTasksForUser(userId);
  }, [userId]);

  const fetchTasksForUser = async (userId: string) => {
    try {
      const response = await taskApi.getAll(userId);
      const result = mapToTaskItems(response);

      setTaskList(result);
      setError(null);
    } catch (err: any) {
      setError(err.message);
      setTaskList([]);
    } finally {
      setLoading(false);
    }
  };

  const handleCreateTask = async (title: string, description: string) => {
    setLoading(true);

    try {
      await taskApi.create({
        title: title,
        description: description,
        userId: userId,
      });

      const tasks = mapToTaskItems(await taskApi.getAll(userId));

      setTaskList(tasks);
      setError(null);
    } catch (err: any) {
      setError(err.message);
      setDeleteResult(false);
    } finally {
      setLoading(false);
    }
  };

  const handleUpdateStatus = async (taskId: string, status: TaskStatus) => {
    setLoading(true);

    const statusEnum = status === "Pending" ? 0 : status === "In Progress" ? 1 : 2;

    try {
      await taskApi.update(taskId, {
        status: statusEnum,
        userId: userId,
      });

      const tasks = mapToTaskItems(await taskApi.getAll(userId));

      setTaskList(tasks);
      setError(null);
    } catch (err: any) {
      setError(err.message);
      setDeleteResult(false);
    } finally {
      setLoading(false);
    }
  };

  const handleUpdateTask = async (taskId: string, title: string, description: string) => {
    setLoading(true);

    try {
      await taskApi.update(taskId, {
        title: title,
        description: description,
        userId: userId,
      });

      const tasks = mapToTaskItems(await taskApi.getAll(userId));

      setTaskList(tasks);
      setError(null);
    } catch (err: any) {
      setError(err.message);
      setDeleteResult(false);
    } finally {
      setLoading(false);
    }
  };

  const handleDeleteTask = async (taskId: string) => {
    setLoading(true);

    try {
      const result = await taskApi.delete(taskId, userId);
      const tasks = mapToTaskItems(await taskApi.getAll(userId));

      setDeleteResult(result);
      setTaskList(tasks);
      setError(null);
    } catch (err: any) {
      setError(err.message);
      setDeleteResult(false);
    } finally {
      setLoading(false);
    }
  };

  return {
    taskList,
    deleteResult,
    error,
    loading,
    handleCreateTask,
    handleUpdateTask,
    handleUpdateStatus,
    handleDeleteTask,
  };
}
