program SpiralGenerated;
{$mode objfpc}{$H+}

function method1(v0: LongInt; v1: AnsiString): AnsiString;
var
  v2: LongInt;
  v3: Boolean;
  v4: LongInt;
  v5: Boolean;
  v8: AnsiString;
  v6: AnsiString;
  v7: AnsiString;
  __spiral_tail_arg0: LongInt;
  __spiral_tail_arg1: AnsiString;
begin
  while True do begin
    v2 := (v0 - 1);
    v3 := (v2 = 0);
    if v3 then begin
      Exit(v1);
    end else begin
      v4 := (v2 mod 2);
      v5 := (v4 = 0);
      if v5 then begin
        v6 := 'ok';
        v8 := v6;
      end else begin
        v7 := 'go';
        v8 := v7;
      end;
      __spiral_tail_arg0 := v2;
      __spiral_tail_arg1 := v8;
      v0 := __spiral_tail_arg0;
      v1 := __spiral_tail_arg1;
      Continue;
    end;
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
  v0 := 1000000;
  v1 := (v0 = 0);
  if v1 then begin
    v2 := 'seed';
    Exit(v2);
  end else begin
    v3 := (v0 mod 2);
    v4 := (v3 = 0);
    if v4 then begin
      v5 := 'ok';
      v7 := v5;
    end else begin
      v6 := 'go';
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
begin
  v0 := method0();
  v1 := Length(v0);
  v2 := (v1 = 2);
  if v2 then begin
    Exit(0);
  end else begin
    Exit(1);
  end;
end;

begin
  Halt(SpiralMain);
end.
