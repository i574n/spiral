program SpiralGenerated;
{$mode objfpc}{$H+}

uses SysUtils;

function SpiralStringIndex(const value: AnsiString; index: LongInt): Byte;
begin
  if (index < 0) or (index >= Length(value)) then raise ERangeError.Create('Spiral string index out of bounds');
  Result := Ord(value[index + 1]);
end;

function SpiralStringConcat(const left, right: AnsiString): AnsiString;
begin
  Result := left + right;
end;

function method2(v0: LongInt; v1: AnsiString; v2: AnsiString): AnsiString;
var
  v3: LongInt;
  v4: AnsiString;
  v5: Boolean;
  v6: LongInt;
  v7: Boolean;
  v10: AnsiString;
  v8: AnsiString;
  v9: AnsiString;
  __spiral_tail_arg0: LongInt;
  __spiral_tail_arg1: AnsiString;
  __spiral_tail_arg2: AnsiString;
begin
  while True do begin
    v3 := (v0 - 1);
    v4 := SpiralStringConcat(v1, v2);
    v5 := (v3 = 0);
    if v5 then begin
      Exit(v4);
    end else begin
      v6 := (v3 mod 2);
      v7 := (v6 = 0);
      if v7 then begin
        v8 := 'ab';
        v10 := v8;
      end else begin
        v9 := 'c';
        v10 := v9;
      end;
      __spiral_tail_arg0 := v3;
      __spiral_tail_arg1 := v4;
      __spiral_tail_arg2 := v10;
      v0 := __spiral_tail_arg0;
      v1 := __spiral_tail_arg1;
      v2 := __spiral_tail_arg2;
      Continue;
    end;
  end;
end;

function method1(v0: LongInt; v1: AnsiString): AnsiString;
var
  v2: LongInt;
  v3: AnsiString;
  v4: Boolean;
  v5: LongInt;
  v6: Boolean;
  v9: AnsiString;
  v7: AnsiString;
  v8: AnsiString;
begin
  v2 := (v0 - 1);
  v3 := SpiralStringConcat('', v1);
  v4 := (v2 = 0);
  if v4 then begin
    Exit(v3);
  end else begin
    v5 := (v2 mod 2);
    v6 := (v5 = 0);
    if v6 then begin
      v7 := 'ab';
      v9 := v7;
    end else begin
      v8 := 'c';
      v9 := v8;
    end;
    Exit(method2(v2, v3, v9));
  end;
end;

function method0: AnsiString;
var
  v0: LongInt;
  v1: Boolean;
  v2: AnsiString;
  v3: LongInt;
  v4: Boolean;
  v7: AnsiString;
  v5: AnsiString;
  v6: AnsiString;
begin
  v0 := 4;
  v1 := (v0 = 0);
  if v1 then begin
    v2 := '';
    Exit(v2);
  end else begin
    v3 := (v0 mod 2);
    v4 := (v3 = 0);
    if v4 then begin
      v5 := 'ab';
      v7 := v5;
    end else begin
      v6 := 'c';
      v7 := v6;
    end;
    Exit(method1(v0, v7));
  end;
end;

function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: LongInt;
  v2: Boolean;
  v3: Byte;
  v4: Boolean;
  v5: Byte;
  v6: Boolean;
begin
  v0 := method0();
  v1 := Length(v0);
  v2 := (v1 = 6);
  if v2 then begin
    v3 := SpiralStringIndex(v0, 0);
    v4 := (v3 = 97);
    if v4 then begin
      v5 := SpiralStringIndex(v0, 5);
      v6 := (v5 = 99);
      if v6 then begin
        Exit(0);
      end else begin
        Exit(1);
      end;
    end else begin
      Exit(2);
    end;
  end else begin
    Exit(3);
  end;
end;

begin
  Halt(SpiralMain);
end.
