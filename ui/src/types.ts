interface Task {
  id: string;
  title: string;
  description: string;
  status: TaskStatus;
  createdDate: Date;
}

type TaskStatus = "pending" | "in-progress" | "completed";
