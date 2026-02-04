import { UserAvatar } from "./UserAvatar";
import { Loading } from "../Core";
import { Alert, Stack, Typography } from "@mui/material";
import { Profile, Task } from "@/types";
import { TaskStatusCount } from "../Task/TaskStatusCount";

interface HeaderProps {
  tasks: Task[];
  profile: Profile;
  loading: boolean;
  error: string | null;
  onAvatarClick: () => void;
}

export const Header = ({ tasks, profile, loading, error, onAvatarClick }: HeaderProps) => {
  if (loading) return <Loading size={30} />;

  return (
    <>
      {error && <Alert severity="error">Error: {error}</Alert>}
      <Stack direction={"row"} sx={{ justifyContent: "space-between", alignItems: "center", width: "100%" }}>
        <UserAvatar profile={profile} onAvatarClick={onAvatarClick} />
        <Typography variant="h4" component={"h6"}>
          My Task List
        </Typography>
        <Typography sx={{ width: 80 }}>&nbsp;</Typography>
      </Stack>
      {tasks && <TaskStatusCount tasks={tasks} />}
    </>
  );
};
