export interface Task {
  id: string;
  title: string;
  description: string;
  status: TaskStatus;
  createdDate: Date;
  userId: string;
}

export type TaskStatus = "Pending" | "In Progress" | "Completed";

export interface Profile {
  userId: string;
  imageBase64: string;
  contentType: string;
}
