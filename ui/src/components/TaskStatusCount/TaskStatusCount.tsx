interface TaskStatusCountProps {
  type: "pending" | "in-progress" | "completed";
  count: number;
}

export const TaskStatusCount = ({ type, count }: TaskStatusCountProps) => {
  return <></>;
};
