RHEL implements network teaming with a small `kernel driver` and a user-space daemon, `teamd`

Software, called `runners`, implements load balancing and active-backup logic, such as roundrobin.

When controlling a team interface using NetworkManager, or when troubleshooting it, you should keep the following facts in mind:

* Starting the team interface does not automatically start its port interfaces.
* Starting a port interface always starts the team interface.
* Stopping the team interface also stops the port interfaces.
* A team interface without ports can start static IP connections.
* A team interface without ports waits for ports when starting DHCP connections.
* If a team interface has a DHCP connection and is waiting for ports, it completes its activation when a port with a carrier signal is added.
* If a team interface has a DHCP connection and is waiting for ports, it continues to wait when a port without a carrier signal is added.

# Create a team interface

```sh
nmcli con add type team con-name CONN_NAME ifname IFACE_NAME team.runner RUNNER

nmcli con add type team con-name team0 ifname team0 team.runner loadbalance

nmcli con mod team0 ipv4.addresses 192.0.2.4/24

nmcli con mod team0 ipv4.method manual
```

## Create the Port Interfaces

```sh
nmcli con add type team-slave con-name team0-eth1 ifname eth1 master team0
nmcli con add type team-slave con-name team0-eth2 ifname eth2 master team0
```

## Bring the Team and Port Interfaces Up or Down

```sh
nmcli con up team0
nmcli con up team0-eth1

teamdctl team0 state
```

# Troubleshooting Network Teams
