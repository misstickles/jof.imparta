"use client";

import { List, ListItem, ListItemButton, ListItemText, Paper, Typography } from "@mui/material";
import { useRouter } from "next/navigation";

interface User {
  name: string;
  subName: string;
  id: string;
}

export const LoginForm = () => {
  const router = useRouter();

  // some temporary users
  const users = [
    { name: "Han Solo", subName: "(honest)", id: "10017dc4-df8f-4a01-ad4d-5a0b62e7ff48" },
    { name: "Arnold Rimmer", subName: "Flying Ace", id: "97b81a67-1775-4253-be07-c73605334517" },
  ] as User[];

  const selectUser = (user: User) => {
    router.push(`/tasks/${user.id}`);
  };

  return (
    <Paper elevation={4} square={false} sx={{ padding: 10 }}>
      <Typography variant="h3" component={"h3"}>
        Who Am I?
      </Typography>
      <List sx={{ width: "100%", bgcolor: "background.paper" }}>
        {users.map((u) => {
          return (
            <ListItem alignItems="flex-start" disableGutters disablePadding key={u.id}>
              <ListItemButton onClick={() => selectUser(u)}>
                <ListItemText primary={u.name} secondary={u.subName} />
              </ListItemButton>
            </ListItem>
          );
        })}
      </List>
    </Paper>
  );
};
