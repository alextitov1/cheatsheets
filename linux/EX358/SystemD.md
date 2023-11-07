

```sh
# list systemd unit types
systemctl -t help

# list all units
systemctl
## list service units
systemctl --type=service

systemctl --failed --type=service

systemctl is-active sshd
systemctl is-enabled sshd

# View the enabled and disabled settings for all units
systemctl list-unit-files --type=service

systemctl list-dependencies sshd
systemctl list-dependencies sshd --reverse

# To avoid accidentally starting a service, you can mask that service
# A disabled service is not started automatically at boot or by other unit files, but can be started manually. A masked service cannot be started manually or automatically.
systemctl mask iptables
systemctl unmask iptables
```