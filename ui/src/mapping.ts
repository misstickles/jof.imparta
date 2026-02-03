// eslint-disable-next-line @typescript-eslint/no-explicit-any
export const mapToTaskItem = (task: any) => {
  return {
    id: task.id,
    title: task.title,
    description: task.description,
    status: mapStatus(task.status),
    createdDate: new Date(task.DateCreated),
    userId: task.userId,
  };
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
