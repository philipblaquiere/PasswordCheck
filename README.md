# PasswordCheck Console Application
PasswordCheck provides an easy way to check a password's strength. It provides a customizable (through code) set of rules the password can be tested upon. It also interprets the resulting passwords score in plain english.

PasswordCheck doesn't define industry-leading password strength regulations. Quite the contrary, it provides a framework for developers to __experiment__ and __test__ custom rules sets, their weightings, and ranking systems.

# At a glance:

- Compatible with __.NET Core__, __C# 7.1+__
- Facilitates defining new rules to test upon
- Verify if password has been pnd on [haveibeenpned.com](https://haveibeenpned.com/API/v2/)
- Provides recommendations for a strong(er) password
- Flexible, customizable ranking system (for password strength/score interpretation)


# Getting Started with the PasswordChecker

To build PasswordCheck Console Application locally:

```bash
git clone https://github.com/philipblaquiere/PasswordCheck.git
cd PasswordCheck/PasswordCheck
dotnet watch build
```

## Commands
The following are commands that can be used to check password strength, as well as explore the available set of rules to test upon.

### `help`
At any time, type `-h` or `--help` to see the available list of commands.

### `check`
To check a password's strength, use the `check` verb followed by `-p` option 

```
check -p Password1234
```

To provide a detailed password check response, including recommendations, include `-d` option

```
check -p Password1234 -d
```

To verify if the password has been pnd include the `-h` option

```
check -p Password1234 -h
```

To specificy a `ruleset` to test the password upon, include the `-r` option followed by the `ruleset`'s name.

```
check -p Password1234 -r CustomRuleSet1
```

To specify a `ranking` to test the score upon, include the `-k` option followed by `ranking`'s name
```
check -p Password1234 -k CustomRankings1
```

All options can be combined, eg.

```
check -p Password1234 -r CustomRuleSet1 -l CustomRankings1 -h -d
```

### `ruleset`
Provides the list of available `ruleset`'s (also by using `-l` option)

```
ruleset
```

To see the specific rules in each ruleset, use the `-d` option followed by the `ruleset`'s name

```
ruleset -d Default
```

### `ranking`
Provides the list of available `ranking`'s (also by using `-l` option)

```
ranking
```

To see the specific rules in each ruleset, use the `-d` option followed by the `ranking`'s name

```
ranking -d Default
```

# Password Scores and Rankings

Password scores are calculated depending on the `Weight` property of a given `Rule`. Each `Rule` that is deemed satisfied by the `Password` will then get its `Weight` summed to represent a `Score`.

The resulting `Score` is then interpreted upon the given `Ranking` set in the following way:

1. The minimum between the resulting summed score and the `RuleSet` maximum score is taken
1. The result found previously is divided by the given `RuleSet`'s maximum score is found to find the % score
1. The resulting % score is multipled by the given `Ranking`'s maximum score.
1. Its ceiling is returned as the resulting score

This method allows for a score to always be 'fitted' proportional to the `Ranking`.

The fitted score is then matched to the lowest common value in the `Ranking` (eg. a fitted score of 6 would match a `Ranking` score of 4 for the given `Ranking` set `{0, 2, 4, 7}`).