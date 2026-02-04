"use client";

import { User } from "@/types";
import { List, ListItem, ListItemButton, ListItemText, Paper, Typography } from "@mui/material";

interface LoginFormProps {
  users: User[];
  onSelectUser: (user: User) => void;
}

export const LoginForm = ({ users, onSelectUser }: LoginFormProps) => {
  return (
    <Paper elevation={4} square={false} sx={{ padding: 10 }}>
      <Typography variant="h3" component={"h3"}>
        Who Am I?
      </Typography>
      <List sx={{ width: "100%", bgcolor: "background.paper" }}>
        {users.map((u) => {
          return (
            <ListItem alignItems="flex-start" disableGutters disablePadding key={u.id}>
              <ListItemButton onClick={() => onSelectUser(u)}>
                <ListItemText primary={u.name} secondary={u.subName} />
              </ListItemButton>
            </ListItem>
          );
        })}
      </List>
    </Paper>
  );
};
