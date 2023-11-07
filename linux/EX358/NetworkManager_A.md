```sh
yum install rhel-system-roles
```

```yaml
- name: Find 2nd network interface
  hosts: servers
  become: true
  vars:
    target_mac: "52:54:00:01:fa:0a"
  tasks:

    - name: Find the_interface for target_mac
      set_fact:
        the_interface: "{{ item }}"
      when:
        - ansible_facts[item]['macaddress'] is defined
        - ansible_facts[item]['macaddress'] == target_mac
      loop: "{{ ansible_facts['interfaces'] }}"

    - name: Display the_interface
      debug:
        var: the_interface
```


```yaml
---
- name: Configure 2nd network interface
  hosts: servers
  become: true

  vars:
    target_mac: "52:54:00:01:fa:0a"
    network_connections:
      - name: static_net
        type: ethernet
        mac: "{{ target_mac }}"
        state: up
        ip:
          dhcp4: no
          address:
            - 192.168.0.1/24
  roles:
    - rhel-system-roles.network

# nmcli con show
# nmcli con show static_net | grep ipv4
```