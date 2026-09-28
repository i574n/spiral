program SpiralGenerated;
{$mode objfpc}{$H+}

type
  Tuple0 = record
    v0: LongInt;
    v1: LongInt;
    v2: Boolean;
  end;
  Tuple1 = record
    v1: Single;
    v2: LongInt;
    v0: Boolean;
  end;

function TupleCreate0(v0: LongInt; v1: LongInt; v2: Boolean): Tuple0;
begin
  Result.v0 := v0;
  Result.v1 := v1;
  Result.v2 := v2;
end;

function TupleCreate1(v0: Boolean; v1: Single; v2: LongInt): Tuple1;
begin
  Result.v1 := v1;
  Result.v2 := v2;
  Result.v0 := v0;
end;

function method1(v0: LongInt): Tuple0;
var
  v1: LongInt;
  v2: Boolean;
begin
  v1 := (v0 + 2);
  v2 := (v0 > 0);
  Exit(TupleCreate0(v0, v1, v2));
end;

function method2(v0: LongInt; v1: LongInt; v2: Boolean): LongInt;
var
  v3: LongInt;
  v4: LongInt;
begin
  if v2 then begin
    v3 := (v0 + v1);
    v4 := (v3 - 4);
    Exit(v4);
  end else begin
    Exit(1);
  end;
end;

function method4(v0: Single): Tuple1;
var
  v1: Boolean;
begin
  v1 := (v0 >= 3.5);
  Exit(TupleCreate1(v1, v0, 7));
end;

function method5(v0: Boolean; v1: Single; v2: LongInt): LongInt;
var
  v3: Boolean;
  v4: LongInt;
begin
  if v0 then begin
    v3 := (v1 >= 3.5);
    if v3 then begin
      v4 := (v2 - 7);
      Exit(v4);
    end else begin
      Exit(1);
    end;
  end else begin
    Exit(2);
  end;
end;

function method7(v0: AnsiString): Boolean;
var
  v1: Boolean;
begin
  v1 := (v0 = v0);
  Exit(v1);
end;

function method9(v0: LongWord): Boolean;
var
  v1: LongWord;
  v2: LongWord;
  v3: Boolean;
begin
  v1 := (v0 + 5);
  v2 := (v1 mod 4);
  v3 := (v2 = 0);
  Exit(v3);
end;

function method11(v0: LongInt; v1: LongInt): LongInt;
var
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
begin
  v2 := (v0 * v1);
  v3 := (v2 + 5);
  v4 := (v3 div 3);
  Exit(v4);
end;

function method10(v0: LongInt): LongInt;
var
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
begin
  v1 := 4;
  v2 := 4;
  v3 := method11(v1, v2);
  v4 := (v0 + v3);
  v5 := (v4 - 7);
  Exit(v5);
end;

function method8(v0: LongInt): LongInt;
var
  v1: LongWord;
  v2: Boolean;
begin
  v1 := 7;
  v2 := method9(v1);
  if v2 then begin
    Exit(method10(v0));
  end else begin
    Exit(1);
  end;
end;

function method6(v0: LongInt): LongInt;
var
  v1: AnsiString;
  v2: Boolean;
begin
  v1 := 'spiral';
  v2 := method7(v1);
  if v2 then begin
    Exit(method8(v0));
  end else begin
    Exit(1);
  end;
end;

function method3(v0: LongInt): LongInt;
var
  v1: Single;
  v2: Boolean;
  v3: Single;
  v4: LongInt;
  tmp1: Tuple1;
  v5: LongInt;
  v6: LongInt;
begin
  v1 := 4.0;
  tmp1 := method4(v1);
  v2 := tmp1.v0;
  v3 := tmp1.v1;
  v4 := tmp1.v2;
  v5 := method5(v2, v3, v4);
  v6 := (v0 + v5);
  Exit(method6(v6));
end;

function method0(v0: LongInt): LongInt;
var
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
  v4: Boolean;
  tmp0: Tuple0;
  v5: LongInt;
  v6: LongInt;
begin
  v1 := 1;
  tmp0 := method1(v1);
  v2 := tmp0.v0;
  v3 := tmp0.v1;
  v4 := tmp0.v2;
  v5 := method2(v2, v3, v4);
  v6 := (v0 + v5);
  Exit(method3(v6));
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
begin
  v0 := 0;
  Exit(method0(v0));
end;

begin
  Halt(SpiralMain);
end.
