import { Task, TaskStatus } from "./types";

/* eslint-disable @typescript-eslint/no-explicit-any */
const mapToTaskItem = (task: any): Task => {
  const date = task.dateCreated;

  return {
    id: task.id,
    title: task.title,
    description: task.description,
    status: mapStatus(task.status) as TaskStatus,
    createdDate: new Date(date),
    userId: task.userId,
  };
};

export const mapToTaskItems = (tasks: any): Task[] => {
  return tasks.map((i: any) => mapToTaskItem(i));
};

const mapStatus = (status: number) => {
  switch (status) {
    case 0:
      return "Pending";
    case 1:
      return "In Progress";
    case 2:
      return "Completed";
  }
};
