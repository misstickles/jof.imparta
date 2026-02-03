import { useFetchProfile } from "@/hooks/useFetchProfile";
import { UserAvatar } from "./UserAvatar";
import { Loading } from "../Core";

import AddIcon from "@mui/icons-material/Add";
import { Button, Stack, Typography } from "@mui/material";
import { Task } from "@/types";
import { TaskStatusCount } from "../Task/TaskStatusCount";

interface HeaderProps {
  userId: string;
  tasks: Task[];
}

export const Header = ({ userId, tasks }: HeaderProps) => {
  const { profile, error, loading } = useFetchProfile(userId);

  if (loading) return <Loading size={30} />;

  return (
    <>
      <Stack direction={"row"} sx={{ justifyContent: "space-between", alignItems: "center", width: "100%" }}>
        <UserAvatar profile={profile} />
        <Typography variant="h4" component={"h6"}>
          Task List Manager
        </Typography>
        <Button variant="contained" sx={{ bgcolor: "#245C9B" }} size="large" title="Create a new task">
          <AddIcon />
        </Button>
      </Stack>
      <TaskStatusCount tasks={tasks} />
    </>
  );
};
