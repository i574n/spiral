program failure_lifecycle;
{$mode objfpc}{$H+}

uses SysUtils, SpiralTypesCallable;

function AnsiRefCount(const value: AnsiString): PtrInt;
begin
  if Pointer(value) = nil then Exit(0);
  Result := PPtrInt(PByte(Pointer(value)) - (2 * SizeOf(PtrInt)))^;
end;

var
  external: AnsiString;
  closure: ClosureValue0;
  beforeCount: LongInt;
  afterCount: LongInt;
  raised: Boolean;
begin
  external := StringOfChar('a', 3);
  closure := ClosureValueCreate0(external, 0);
  beforeCount := AnsiRefCount(external);
  if beforeCount < 2 then Halt(11);

  raised := False;
  try
    ClosureInvoke0(closure, 39);
  except
    on E: Exception do begin
      if E.Message <> 'package-owned managed closure failure' then Halt(12);
      raised := True;
    end;
  end;
  if not raised then Halt(13);

  afterCount := AnsiRefCount(external);
  if afterCount <> beforeCount then Halt(14);
  closure.v0 := '';
  if AnsiRefCount(external) <> beforeCount - 1 then Halt(15);
  if external <> 'aaa' then Halt(16);
  Halt(42);
end.
