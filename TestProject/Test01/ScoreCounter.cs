﻿using System.Collections.Generic;
using System.IO;

namespace Test01 {
    class ScoreCounter {
        private IEnumerable<Student> _score;

        // コンストラクタ
        public ScoreCounter(string filePath) {
            _score = ReadScore(filePath);
        }


        //メソッドの概要： 
        private static IEnumerable<Student> ReadScore(string filePath) {
            var students = new List<Student>();
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines) {
                var items = line.Split(',');
                var student = new Student {
                    StudentName = items[0],
                    kamoku = items[1],
                    tensu = int.Parse(items[2])
                };
                students.Add(student);
            }
            return students;

        }

        //メソッドの概要： 
        public IDictionary<string, int> GetPerStudentScore() {
            var dict = new Dictionary<string, int>();
            foreach (var score in _score) {
                if (dict.ContainsKey(score.kamoku)) {
                    dict[score.kamoku] += score.tensu;
                } else {
                    dict[score.kamoku] = score.tensu;
                }
            }
            return dict;

        }
    }
}
