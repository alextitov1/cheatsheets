#!/usr/bin/env python3

import unittest
from rearrange import rearrange_name

class TestRearrange(unittest.TestCase):
    def test_basic(self):
        testcase = "Alexander, Titov"
        expected = "Titov Alexander"
        self.assertEqual(rearrange_name(testcase), expected)

    def test_empty(self):
        testcase = ""
        expected = ""
        self.assertEqual(rearrange_name(testcase), expected)

    def test_double_name(self):
        testcase = "Hopper, Grace M."
        expected = "Grace M. Hopper"
        self.assertEqual(rearrange_name(testcase), expected)

    def test_one_name(self):
        testcase = "Alexander"
        expected = "Alexander"
        self.assertEqual(rearrange_name(testcase), expected)

unittest.main()
