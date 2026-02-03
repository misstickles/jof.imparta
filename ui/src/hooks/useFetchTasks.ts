/* eslint-disable @typescript-eslint/no-explicit-any */
import { mapToTaskItem } from "@/mapping";
import { Task } from "@/types";
import { useEffect, useState } from "react";

const apiUrl = process.env.NEXT_PUBLIC_API_BASE_URL as string;

export function useFetchTasks(userId: string) {
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  const [taskList, setTaskList] = useState<Task[]>([] as Task[]);

  useEffect(() => {
    const fetchTasksForUser = async (userId: string) => {
      console.log("User", userId, apiUrl);

      try {
        const response = await fetch(`${apiUrl}/Task/${userId}`);

        if (!response.ok) {
          throw new Error(`HTTP error: Status ${response.status}`);
        }

        const tasksResponse = await response.json();

        const result = tasksResponse.result.map((i: any) => mapToTaskItem(i));

        setTaskList(result);
        setError(null);
      } catch (err: any) {
        setError(err.message);
        setTaskList([]);
      } finally {
        setLoading(false);
      }
    };

    fetchTasksForUser(userId);
  }, [userId]);

  return { taskList, error, loading };
}
