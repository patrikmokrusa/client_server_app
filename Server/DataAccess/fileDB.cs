using System;
using System.Collections.Generic;
using System.IO;

namespace Server.DataAccess
{

    class fileDB
    {
        public string name;
        private Dictionary<int, UserRecord> _usersDict;
        public fileDB(string name)
        {
            this.name = name + ".txt";
            _usersDict = new Dictionary<int, UserRecord>();
            if (!File.Exists(this.name))
            {
                File.WriteAllText(this.name, "");
            }
            Load();
        }

        private void Load()
        {
            _usersDict.Clear();

            if (!File.Exists(name)) return;
            
            var data = File.ReadAllLines(name);
            

            foreach (var line in data)
            {
                if (line == "") continue;
                var userRecord = StrToUserRecord(line);
                _usersDict.Add(userRecord.id, userRecord);
            }

        }

        private void Save()
        {
            File.WriteAllText(name, string.Empty);
            var data = "";
            foreach (var user in _usersDict)
            {
                if (UserRecordToStr(user.Value).EndsWith("\n"))
                {
                    data += UserRecordToStr(user.Value);
                }
                else data += UserRecordToStr(user.Value) + "\n";

            }
            File.WriteAllText(name, data);
        }

        private UserRecord StrToUserRecord(string str)
        {
            var parts = str.Split(' ');
            var trim = parts[2].Split('\n');
            return new UserRecord()
            {
                id = int.Parse(parts[0]),
                name = parts[1],
                surname = trim[0]
            };
        }
        private string UserRecordToStr(UserRecord user)
        {
            return user.id + " " + user.name + " " + user.surname;
        }
        

        public string Get(string id)
        {
            if (!_usersDict.ContainsKey(int.Parse(id))) return "BAD KEY!";
            return UserRecordToStr(_usersDict[int.Parse(id)]);
        }

        public string Edit(string id, string name, string surname)
        {
            if (_usersDict.ContainsKey(int.Parse(id)))
            {
                _usersDict[int.Parse(id)].name = name;
                _usersDict[int.Parse(id)].surname = surname;
                Save();
                return "SUCCESS!";
            }
            return "BAD KEY!";

        }

        public string Delete(string id)
        {
            if (_usersDict.Remove(int.Parse(id)))
            {
                Save();
                return "SUCCESS!";
            }
            return "BAD KEY!";
        }

        public string Add(string name, string surname)
        {
            int key = 1;
            while (_usersDict.ContainsKey(key))
            {
                key++;
            }

            var user = new UserRecord()
            {
                id = key,
                name = name,
                surname = surname
            };
            _usersDict.Add(key, user);
            Save();
            return "SUCCESS!";
        }

        public string GetAll()
        {
            var response = "";
            foreach (var user in _usersDict)
            {
                response += UserRecordToStr(user.Value) + "\n";
            }

            if (response == "") return "NO USERS!";
            return response;
        }
    }
}
